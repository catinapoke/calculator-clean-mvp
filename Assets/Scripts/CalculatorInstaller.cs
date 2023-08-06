using Data;
using Domain;
using Zenject;

public class CalculatorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindStorages();
        BindDomainSpecific();
        BindUseCases();
    }

    private void BindStorages()
    {
        Container.Bind<IInputStorage>().To<InputStorage>().FromNew().AsCached();
        Container.Bind<IResultStorage>().To<ResultStorage>().FromNew().AsCached();
    }

    private void BindDomainSpecific()
    {
        Container.Bind<IEquationSolver>().To<EquationSolver>().FromNew().AsCached();
    }

    private void BindUseCases()
    {
        Container.Bind<RequestSolutionUseCase>().FromNew().AsCached();
        Container.Bind<RestoreInputUseCase>().FromNew().AsCached();
        Container.Bind<RestoreResultUseCase>().FromNew().AsCached();
        Container.Bind<ChangeEquationUseCase>().FromNew().AsCached();
    }
}
