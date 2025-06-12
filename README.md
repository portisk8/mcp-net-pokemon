# Configuración de tu MCP Server en Cursor

Este proyecto implementa un servidor MCP (Model Context Protocol) personalizado, que puedes integrar fácilmente en entornos compatibles como Cursor, Claude Desktop o Github Copilot en VsCode. A continuación, te explico cómo agregar la configuración necesaria para que Cursor reconozca y utilice tu MCP server.

---

## ¿Qué es MCP?

MCP (Model Context Protocol) es un protocolo abierto que permite a aplicaciones y modelos de lenguaje (LLMs) interactuar con servidores que exponen herramientas, recursos y prompts de manera estandarizada. Esto facilita la integración de datos y acciones externas en flujos de trabajo de IA.

---

## Pasos para agregar tu MCP server en Cursor

### 1. Asegúrate de tener tu MCP server listo

Compila y prueba tu servidor MCP localmente. Por ejemplo, si usas .NET:

```sh
dotnet run --project C:\RUTA\A\TU\mcp-pokemon-server.csproj --no-build
```

### 2. Ubica el archivo de configuración de Cursor

En Windows, el archivo de configuración suele estar en:

```
%APPDATA%\Cursor\cursor_config.json
```

Puedes abrirlo rápidamente con VS Code:

```sh
code $env:AppData\Cursor\cursor_config.json
```

O navega manualmente a la carpeta correspondiente.

### 3. Agrega la configuración del MCP server

Dentro del archivo `cursor_config.json`, busca (o crea) la clave `"mcpServers"`. Agrega una entrada para tu servidor, por ejemplo:

```json
{
  "mcpServers": {
    "mcp-pokemon-server": {
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "C:\\RUTA\\A\\TU\\mcp-pokemon-server.csproj",
        "--no-build"
      ]
    }
  }
}
```

- Cambia `"C:\\RUTA\\A\\TU\\mcp-pokemon-server.csproj"` por la ruta absoluta a tu proyecto.
- Puedes agregar varios servidores MCP si lo deseas, cada uno con una clave diferente.

### 4. Guarda y reinicia Cursor

Guarda los cambios y reinicia Cursor para que detecte el nuevo servidor MCP. Si todo está correcto, deberías ver las herramientas expuestas por tu servidor (ícono de martillo o similar).

---

## Consejos

- Describe bien tus herramientas usando los atributos `[Description]` en tu código, ya que Cursor mostrará estas descripciones en la interfaz.
- Puedes consultar el repositorio de modelcontextprotocol para ejemplos de código y mejores prácticas:  
  [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- Si tienes problemas, revisa los logs de Cursor y asegúrate de que tu servidor MCP no tenga errores de ejecución.

---

¡Listo! Ahora tu MCP server está integrado en Cursor y puedes aprovechar todas sus herramientas desde la interfaz. 
