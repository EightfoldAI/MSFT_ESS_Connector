# MSFT ESS Connector

A Python-based connector for Microsoft Enterprise Security Solutions (ESS) that enables seamless integration with Microsoft's security services and APIs.

## Overview

This project provides a robust connector for integrating with Microsoft's Enterprise Security Solutions, enabling seamless data exchange and security operations. It includes support for API management, policy enforcement, and security configurations.

## Features

- Secure authentication and authorization with Microsoft services
- API Management integration with Swagger/OpenAPI support
- Policy enforcement and configuration management
- Resource template management
- Comprehensive error handling and logging
- Type-safe implementation
- CLI and certification configuration support

## Prerequisites

- Python 3.9+
- [uv](https://github.com/astral-sh/uv) for dependency management
- Git
- Microsoft Azure subscription (for API access)
- Appropriate Microsoft security service credentials

## Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/MSFT_ESS_Connector.git
cd MSFT_ESS_Connector
```

2. Create and activate a virtual environment using uv:
```bash
uv venv
source .venv/bin/activate  # On Unix/macOS
# or
.venv\Scripts\activate  # On Windows
```

3. Install dependencies:
```bash
uv pip install -r requirements.txt
```

## Configuration

The connector supports multiple configuration modes:

1. CLI Configuration (`connector-config-cli.json`)
2. Certification Configuration (`connector-config-certification.json`)
3. Internal Configuration (`connector-config-internal.json`)

Update the appropriate configuration file with your Microsoft service credentials and settings.

## Project Structure

```
MSFT_ESS_Connector/
├── apiDefinition.swagger.json    # API definition in Swagger/OpenAPI format
├── connector-config-*.json       # Various configuration files
├── icon.png                      # Connector icon
├── intro.md                      # Detailed documentation
├── policies.xml                  # Policy definitions
├── PolicySourceCode.cs           # Policy implementation
├── resourceTemplate-apimRegister.json  # API Management resource template
└── Microsoft.Azure.Connectors.EightFold.csproj  # Project configuration
```

## Development

1. Install development dependencies:
```bash
uv pip install -r requirements-dev.txt
```

2. Run tests:
```bash
pytest
```

3. Run linting:
```bash
ruff check .
```

## API Integration

The connector uses the Swagger/OpenAPI specification (`apiDefinition.swagger.json`) to define the API endpoints and operations. The resource template (`resourceTemplate-apimRegister.json`) provides the necessary configuration for API Management integration.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Security

Please report any security issues to security@example.com

## Support

For support, please open an issue in the GitHub repository. 