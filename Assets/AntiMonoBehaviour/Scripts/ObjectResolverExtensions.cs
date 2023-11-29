using VContainer;

namespace AntiMonoBehaviour
{
    //https://qiita.com/sakano/items/872a9e4cdf14be0f0c61
    public static class ObjectResolverExtensions
    {
        public static RegistrationBuilder RegisterPlainEntryPoint<T>(this IContainerBuilder builder,
            Lifetime lifetime = Lifetime.Singleton)
        {
            builder.RegisterBuildCallback(objectResolver => objectResolver.Resolve<T>());
            return builder.Register<T>(lifetime);
        }
    }
}
