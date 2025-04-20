using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DM2GM
{
    public static class MenuConverter
    {
        // 材质映射表
        public static Dictionary<string, string> MaterialMap = [];

        // DeluxeMenus数据结构
        private class DmConfig
        {
            [YamlMember(Alias = "menu_title")]
            public string Title { get; set; } = string.Empty; // 初始化为默认空字符串

            public Dictionary<string, DmItem> Items { get; set; } = []; // 初始化为空字典
        }

        private class DmItem
        {
            [YamlMember(Alias = "material")]
            public string Material { get; set; } = string.Empty; // 初始化为默认空字符串

            [YamlMember(Alias = "display_name")]
            public string DisplayName { get; set; } = string.Empty; // 初始化为默认空字符串

            [YamlMember(Alias = "commands")]
            public List<string> Commands { get; set; } = []; // 初始化为空列表

            [YamlMember(Alias = "left_click_commands")]
            public List<string> LeftClickCommands { get; set; } = []; // 初始化为空列表

            [YamlMember(Alias = "right_click_commands")]
            public List<string> RightClickCommands { get; set; } = []; // 初始化为空列表
        }

        // GeyserMenus数据结构
        private class GmConfig
        {
            public GmMenu Menu { get; set; } = new GmMenu(); // 初始化为新的 GmMenu 实例
        }

        private class GmMenu
        {
            [YamlMember(Alias = "title", ScalarStyle = YamlDotNet.Core.ScalarStyle.DoubleQuoted)]
            public string Title { get; set; } = string.Empty; // 初始化为默认空字符串
            public List<GmItem> Items { get; set; } = []; // 初始化为空列表
        }

        private class GmItem
        {
            [YamlMember(Alias = "text", ScalarStyle = YamlDotNet.Core.ScalarStyle.DoubleQuoted)]
            public string Text { get; set; } = string.Empty;

            [YamlMember(Alias = "icon", ScalarStyle = YamlDotNet.Core.ScalarStyle.DoubleQuoted)]
            public string Icon { get; set; } = string.Empty;

            [YamlMember(Alias = "icon_type", ScalarStyle = YamlDotNet.Core.ScalarStyle.DoubleQuoted)]
            public string IconType { get; set; } = "java";

            [YamlMember(Alias = "command", ScalarStyle = YamlDotNet.Core.ScalarStyle.DoubleQuoted)]
            public string Command { get; set; } = string.Empty;
        }





        public static string Convert(string inputYaml, string inputMMap)
        {
            MaterialMap = ParseMaterialMappings(inputMMap);

            try
            {
                // 反序列化输入
                var dm = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .IgnoreUnmatchedProperties()
                    .Build()
                    .Deserialize<DmConfig>(inputYaml);

                // 构建输出对象
                var gm = new GmConfig
                {
                    Menu = new GmMenu
                    {
                        Title = dm.Title,
                        Items = []
                    }
                };

                // 转换每个物品项
                foreach (var item in dm.Items)
                {
                    if (ShouldSkipItem(item.Key)) continue;

                    var gmItem = ConvertItem(item.Value);
                    if (gmItem != null)
                    {
                        gm.Menu.Items.Add(gmItem);
                    }
                }

                // 序列化输出
                return new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
                    .Build()
                    .Serialize(gm);
            }
            catch (Exception ex)
            {
                return $"转换失败：{ex.Message}";
            }
        }

        private static bool ShouldSkipItem(string itemKey)
        {
            // 跳过包含这些关键词的装饰性物品
            return itemKey.Contains("border", StringComparison.OrdinalIgnoreCase);
        }

        private static GmItem? ConvertItem(DmItem dmItem)
        {
            var command = GetFirstCommand(dmItem);
            if (string.IsNullOrEmpty(command)) return null;

            return new GmItem
            {
                Text = dmItem.DisplayName?.Trim() ?? "",
                Icon = GetMappedMaterial(dmItem.Material),
                Command = command
            };
        }

        private static string GetFirstCommand(DmItem item)
        {
            // 优先级：Commands > LeftClickCommands > RightClickCommands
            var cmd = item.Commands?.FirstOrDefault()
                   ?? item.LeftClickCommands?.FirstOrDefault()
                   ?? item.RightClickCommands?.FirstOrDefault();

            return CleanCommand(cmd!);
        }

        private static string CleanCommand(string command)
        {
            return command
                .Replace("[player]", "")
                .Trim('[', ']', ' ')
                .Trim();
        }

        private static string GetMappedMaterial(string material)
        {
            if (string.IsNullOrWhiteSpace(material))
                return "textures/items/barrier";

            return MaterialMap.TryGetValue(material, out var mapped)
                ? mapped
                : "textures/items/barrier";
        }

        public static Dictionary<string, string> ParseMaterialMappings(string input)
        {
            var mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // 正则表达式匹配 ["KEY"] = "VALUE" 格式
            var regex = new Regex(@"\[\""(.+?)\""\]\s*=\s*\""(.+?)\""", RegexOptions.Multiline);

            foreach (Match match in regex.Matches(input))
            {
                if (match.Groups.Count == 3) // 确保捕获到键和值
                {
                    string key = match.Groups[1].Value;
                    string value = match.Groups[2].Value;

                    if (!mappings.ContainsKey(key))
                    {
                        mappings.Add(key, value);
                    }
                }
            }

            return mappings;
        }
    }
}