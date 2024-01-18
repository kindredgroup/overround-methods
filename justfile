_help:
    @just --list

# runs the example app
run *ARGS:
    dotnet run --project App/App.csproj {{ARGS}}

# runs the test cases
test:
    dotnet test
