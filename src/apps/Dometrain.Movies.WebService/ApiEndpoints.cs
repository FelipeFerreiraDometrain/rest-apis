namespace Dometrain.Movies.WebService;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Movies
    {
        private const string Base = $"{ApiBase}/movies";

        public const string Create = Base;
        public const string GetAll = Base;
        public const string GetByIdOrSlug = $"{Base}/{{idOrSlug:required}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
}