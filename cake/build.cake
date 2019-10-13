#addin "Cake.Incubator&version=5.0.1"

using System;
using System.Diagnostics;

var testDir = "../tests";
var projects = GetFiles("../src/**/*.csproj");
var testProject = GetFiles(testDir + "/**/*.csproj").FirstOrDefault();

var target = Argument("target", "Default");

Task("Default")
    .IsDependentOn("Test");

Task("Restore")
    .Does(() =>
    {
        foreach (var project in projects)
        {
            DotNetCoreRestore(project.ToString());
        }
    });

Task("Restore-Test")
    .Does(() =>
    {
        DotNetCoreRestore(testProject.ToString());
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    foreach (var project in projects)
    {
        DotNetCoreBuildSettings settings = new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = "Release"
        };
    
        DotNetCoreBuild(project.ToString(), settings);
    }
});

Task("Build-Test")
    .IsDependentOn("Restore-Test")
    .Does(() => 
    {
        DotNetCoreBuildSettings settings = new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = "Release"
        };
    
        DotNetCoreBuild(testProject.ToString(), settings);
    });

Task("Test")
    .IsDependentOn("Build")
    .IsDependentOn("Build-Test")
    .Does(() => 
    {
        DotNetCoreTestSettings settings = new DotNetCoreTestSettings
        {
            Configuration = "Release",
            NoBuild = true
        };

        DotNetCoreTest(testProject.FullPath, settings);
    });

Task("Pack-JasonState")
    .Description("Publish to nuget")
    .Does(() =>
    {
        var settings = new DotNetCorePackSettings
        {
            Configuration = "Release",
            WorkingDirectory = "../src/JasonState",
            OutputDirectory = "../artifacts"
        };

        DotNetCorePack("JasonState.csproj", settings);
    });

Task("Pack-Extension")
    .Description("Publish to nuget")
    .Does(() =>
    {
        var settings = new DotNetCorePackSettings
        {
            Configuration = "Release",
            WorkingDirectory = "../src/JasonState.Extension",
            OutputDirectory = "../artifacts"
        };

        DotNetCorePack("JasonState.Extension.csproj", settings);
    });

RunTarget(target);