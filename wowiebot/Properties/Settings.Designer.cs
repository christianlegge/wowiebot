﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wowiebot.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string prevChannel {
            get {
                return ((string)(this["prevChannel"]));
            }
            set {
                this["prevChannel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string userCookie {
            get {
                return ((string)(this["userCookie"]));
            }
            set {
                this["userCookie"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string oauthCookie {
            get {
                return ((string)(this["oauthCookie"]));
            }
            set {
                this["oauthCookie"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />")]
        public global::System.Collections.Specialized.StringCollection quotes {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["quotes"]));
            }
            set {
                this["quotes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("!")]
        public string prefix {
            get {
                return ((string)(this["prefix"]));
            }
            set {
                this["prefix"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool enableQuotes {
            get {
                return ((bool)(this["enableQuotes"]));
            }
            set {
                this["enableQuotes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool enableUptime {
            get {
                return ((bool)(this["enableUptime"]));
            }
            set {
                this["enableUptime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool enableTitle {
            get {
                return ((bool)(this["enableTitle"]));
            }
            set {
                this["enableTitle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool enableLinkTitles {
            get {
                return ((bool)(this["enableLinkTitles"]));
            }
            set {
                this["enableLinkTitles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool enableDiscord {
            get {
                return ((bool)(this["enableDiscord"]));
            }
            set {
                this["enableDiscord"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string discordServer {
            get {
                return ((string)(this["discordServer"]));
            }
            set {
                this["discordServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool enable8Ball {
            get {
                return ((bool)(this["enable8Ball"]));
            }
            set {
                this["enable8Ball"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>yes</string>
  <string>no</string>
  <string>try again later</string>
  <string>maybe~</string>
  <string>idk ask scatter</string>
  <string>hecc no</string>
  <string>hecc yeah</string>
  <string>you wish</string>
  <string>signs point to yes</string>
  <string>signs point to no</string>
  <string>4 shur</string>
  <string>i know nothing don't ask me again please i'm just a young bot D:</string>
  <string>what do you think ;)</string>
  <string>yank train</string>
  <string>nuns on ripple</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection choices8Ball {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["choices8Ball"]));
            }
            set {
                this["choices8Ball"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string commandsDataTableJson {
            get {
                return ((string)(this["commandsDataTableJson"]));
            }
            set {
                this["commandsDataTableJson"] = value;
            }
        }
    }
}
