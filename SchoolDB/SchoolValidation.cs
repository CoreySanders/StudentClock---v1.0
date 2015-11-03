using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDB
{
    public class SchoolValidation
    {
        //School Entity Framework
        private static SchoolDataEntities schoolEntity = new SchoolDataEntities();

        public static Boolean IsPresent(TextBox textbox)
        {
            bool isPresent = textbox.Text != "" ? true : false;
            return isPresent;
        }

        public static Boolean MassTextCheck(TextBox[] textboxes)
        {
            bool validTexts = true;
            for (int i = 0; i > textboxes.Length; i++)
            {
                if (!IsPresent(textboxes[i]))
                {
                    validTexts = false;
                }
            }
            return validTexts;
        }

        public static void FillStateComboBox(ComboBox cbo)
        {
            var states = from state in schoolEntity.EFStates
                        orderby state.StateName
                        select new
                        {
                            state.StateName,
                            state.StateCode
                        };
            cbo.DataSource = states.ToList();
            cbo.DisplayMember = "StateName";
            cbo.ValueMember = "StateCode";
        }

        public static Boolean IsPositiveInt(string text)
        {
            int id;
            if (int.TryParse(text, out id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool StringToInt(string text, out int integer)
        {
            if (IsPositiveInt(text))
            {
                integer = int.Parse(text);
                return true;
            }
            else
            {
                integer = 0;
                return false;
            }
        }
    }
}
