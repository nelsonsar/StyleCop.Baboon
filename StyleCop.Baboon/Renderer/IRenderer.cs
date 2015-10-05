namespace StyleCop.Baboon.Renderer
{
    using System;
    using StyleCop.Baboon.Analyzer;

    public interface IRenderer
    {
        void RenderViolationList(ViolationList violationList);
    }
}
