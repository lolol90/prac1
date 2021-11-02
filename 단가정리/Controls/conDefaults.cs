// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.conDefaults
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System.Drawing;

namespace smartMain.Controls
{
    internal static class conDefaults
    {
        public const string Theme = "Light";
        public const string Style = "Blue";
        public const conBorderStyle BorderStyle = conBorderStyle.None;
        public const float FontSize = 14f;
        public const string CatAppearance = "con 모양 설정";
        public const string CatBehavior = "con Behavior";
        public const string CatDataField = "con 데이터 설정";
        public static bool FormSuspendLayoutDuringResize = false;
        public static bool DrawFocusRectangle = false;
        public static readonly string FontFamily = SystemFonts.DefaultFont.Name;
        public static readonly FontStyle FontStyle = SystemFonts.DefaultFont.Style;
    }
}
