using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IFlowchartPresenter : IPresenter
    {
        void AddBlock(string str, int x, int y);
        void EditBlock(string str, int x, int y);
        void RemoveBlock(int x, int y);
        bool IsEdge(int xCoordsClick, int yCoordsClick);
        bool IsSquareBlock(int xCoordsClick, int yCoordsClick);
        void ToCode();
    }

    class MasterPresenter : IFlowchartPresenter
    {
        public void Run() { }
        public void AddBlock(string str, int x, int y) { }
        public void EditBlock(string str, int x, int y) { }
        public void RemoveBlock(int x, int y) { }
    }

    class ReviewerPresenter : IFlowchartPresenter
    {
        public void Run() { }
        public void AddBlock(string str, int x, int y) { }
        public void EditBlock(string str, int x, int y) { }
        public void RemoveBlock(int x, int y) { }
    }
}
