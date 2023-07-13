namespace ApplicationService.Common
{
    public abstract class AssemblerBase<T , U> where T : class where U : class
    {
        public abstract U ToPoco(T poco);
    }
}
