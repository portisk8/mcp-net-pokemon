using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MCP.Server.Tools
{
    [McpServerToolType]
    public static class PokemonTools
    {
        private const string BaseUrl = "https://pokeapi.co/api/v2";

        [McpServerTool, Description("Obtiene una lista de Pokémones con paginación")]
        public static async Task<string> ListPokemon(HttpClient httpClient, 
            [Description("Número máximo de Pokémones a obtener (por defecto 20, máximo 100)")] int limit = 20,
            [Description("Número de Pokémones a omitir para paginación (por defecto 0)")] int offset = 0)
        {
            try
            {
                if (limit > 100) limit = 100;
                if (offset < 0) offset = 0;

                var url = $"{BaseUrl}/pokemon?limit={limit}&offset={offset}";

                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        [McpServerTool, Description("Obtiene información detallada de un Pokémon específico")]
        public static async Task<string> GetPokemon(HttpClient httpClient, 
            [Description("Nombre o ID del Pokémon a buscar")] string pokemon)
        {
            try
            {
                var url = $"{BaseUrl}/pokemon/{pokemon.ToLower()}";
                var response = await httpClient.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return $"Pokémon '{pokemon}' no encontrado";

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        [McpServerTool, Description("Obtiene información sobre un tipo de Pokémon y los Pokémones que lo tienen")]
        public static async Task<string> GetPokemonType(HttpClient httpClient, 
            [Description("Nombre del tipo de Pokémon (ej: fire, water, grass)")] string type)
        {
            try
            {
                var url = $"{BaseUrl}/type/{type.ToLower()}";

                var response = await httpClient.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return $"Tipo '{type}' no encontrado";

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca Pokémones por nombre parcial")]
        public static async Task<string> SearchPokemon(HttpClient httpClient, 
            [Description("Texto a buscar en el nombre del Pokémon")] string query,
            [Description("Número máximo de resultados (por defecto 50)")] int limit = 50)
        {
            try
            {
                var url = $"{BaseUrl}/pokemon?limit=1000";

                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }

}
