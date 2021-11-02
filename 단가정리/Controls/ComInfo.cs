using System;
using System.Windows.Forms;

namespace smartMain.Controls
{
    internal class ComInfo
    {
        public static void onlyNum(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
        }

        public static void onlyNum2(object sender, KeyPressEventArgs e) //실수 포함
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) ||
                  e.KeyChar == '.')) //숫자와 백스페이스, 소수점을 제외한 나머지를 바로 처리
                e.Handled = true;
        }

        public static void onlyNum3(object sender, KeyPressEventArgs e) //실수, 음수 포함
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.' ||
                  e.KeyChar == '-')) //숫자와 백스페이스, 소수점을 제외한 나머지를 바로 처리
                e.Handled = true;
        }

    }
}
