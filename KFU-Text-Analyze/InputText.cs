using System;

namespace KFU_Text_Analyze
{
    class InputText
    {
        private static String Text { get; set; } = "";
        private static InputText instance = null;
        private InputText()
        {
        }
        public static InputText GetInstance()
        {
            if (InputText.instance == null)
            {
                instance = new InputText();
            }
            return instance;
        }
    }
}
