using Metalama.Framework.Code;
using Metalama.Framework.Fabrics;
using metalama_library;

namespace metalama_demo.metalama;

internal class Fabric : ProjectFabric
{
    // This method is the compile-time entry point of your project.
    // It executes within the compiler or IDE.
    public override void AmendProject(IProjectAmender project)
    {
        AddLogging(project);
        //AddRetry(project);
        AddProfiling(project);
    }

    private void AddProfiling(IProjectAmender project)
    {
        project
            .SelectMany(p => p.Types.Where(t => t.Accessibility == Accessibility.Public))
            .SelectMany(t => t.Methods.Where(m => m.Accessibility == Accessibility.Public))
            .AddAspectIfEligible<Profile>();
    }

    private void AddLogging(IProjectAmender project)
    {
        project.SelectMany(p => p.Types.SelectMany(t => t.Methods)
            .Where(m => m.Accessibility == Accessibility.Public)
        )
        .AddAspectIfEligible<Log>();
        
    }

    //private void AddRetry(IProjectAmender project)
    //{
    //    project.SelectMany(p => p.Types.SelectMany(t => t.Methods)
    //        .Where(m => m.Accessibility == Accessibility.Public)
    //    )
    //    .AddAspectIfEligible<Retry>();
    //}
}
