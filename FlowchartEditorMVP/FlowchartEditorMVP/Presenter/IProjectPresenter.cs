using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IProjectPresenter
    {
        int Check(string fcName, string fileName, int lang); // возвращает результат проверки введенных в поля данных
    }

    class ProjectPresenter : IProjectPresenter
    {
        public int Check(string fcName, string fileName, int lang)
        {
            if (fcName == "")
            {
                return 1;
            }
            else
                if (fileName == "")
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
        }
    }
        
}
