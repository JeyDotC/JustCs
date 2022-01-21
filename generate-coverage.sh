#!/bin/bash

if ! command -v dotnet coverage &> /dev/null
then
    echo "dotnet coverage command not found, installing...";
    dotnet tool install --global dotnet-coverage && echo "dotnet coverage installed."
fi

if [ ! -f "./tools/reportgenerator" ]; then
    echo "reportgenerator not found, installing...";
    dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools && "reportgenerator installed."
fi

rm -R ./coverage
echo "Collecting coverage data: " && dotnet coverage collect "dotnet test" -f cobertura -s ./CoverageSettings.xml && \
echo "Generating report: " && ./tools/reportgenerator "-reports:output.cobertura.xml" "-targetdir:coverage" && \
rm ./output.cobertura.xml