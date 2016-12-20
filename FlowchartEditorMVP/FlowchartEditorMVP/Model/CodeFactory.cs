namespace FlowchartEditorMVP.Model
{
    interface CodeFactory
    {
        ICode CreateCode(IFlowchart flowchart);
    }

    class CppFactory : CodeFactory
    {
        public ICode CreateCode(IFlowchart flowchart)
        {
            return new CppCode(flowchart);
        }
    }
}
