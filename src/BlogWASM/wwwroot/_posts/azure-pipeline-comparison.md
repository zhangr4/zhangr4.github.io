---
title: "Azure Pipelines: Multi-Stage(YAML-base) Pipeline vs. Classic Pipeline"
author: Zhangr4
date: 2025-MAR-16
tags:  
  - Azure Pipeline, 
  - CI/CD
---

Azure Pipelines offers two primary types of pipelines for CI/CD: [yaml based pipeline and Classic Pipelines](https://learn.microsoft.com/en-us/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops). Within yaml based pipeline, Multi-Stage Pipelines can help combine build and release into single pipeline. Below is a comparison of these two pipeline types based on various aspects.

<!-- more -->

## Overview

### Multi-Stage(YAML-based) Pipeline

- **Definition**: YAML-based pipelines that define CI/CD as code.
- **Flexibility**: Highly flexible and customizable.
- **Version Control**: Pipeline definitions are stored in source control, enabling versioning and collaboration.
- **Stages**: Supports multiple stages, jobs, and steps within a single pipeline file.
- **Reusability**: Allows for reusable templates and modular pipeline components.

### Classic Pipeline

- **Definition**: GUI-based pipelines created and managed through the Azure DevOps portal.
- **Ease of Use**: User-friendly interface for creating and managing pipelines.
- **Version Control**: Pipeline definitions are not stored in source control by default.
- **Stages**: Supports multiple stages but less flexible compared to YAML-based pipelines. Can combined use with release pipeline.
- **Reusability**: Limited reusability and modularity compared to YAML-based pipelines.

## Comparison Table

| Aspect                | Multi-Stage Pipeline                  | Classic Pipeline                      |
|-----------------------|---------------------------------------|---------------------------------------|
| **Definition**        | YAML-based                            | GUI-based                             |
| **Flexibility**       | ✔ High                                | ✖ Moderate                            |
| **Version Control**   | ✔ Stored in source control with code            | ✔ versions can be found in azure devops, but not stored together with code |
| **Multiple Stages**            | ✔ | ✔             |
| **Reusability**       | ✔ High (templates, modular components) | ✖ Limited                             |
| **Ease of Use**       | ✖ Requires YAML knowledge             | ✔ User-friendly interface             |
| **Customization**     | ✔ Highly customizable                 | ✖ Limited customization               |
| **Pipeline as Code**  | ✔ Yes                                 | ✖ No                                  |
| **Collaboration**     | ✔ Easy collaboration via source control | ✖ Limited collaboration               |
| **Maintenance**       | ✔ Easier to maintain with versioning  | ✖ Harder to maintain without versioning |
| **Integration**       | ✔ Better integration with modern DevOps practices | ✔ Suitable for simpler use cases       |

## Key Differences

### Flexibility and Customization

- **Multi-Stage Pipeline**: Offers high flexibility and customization through YAML. You can define complex workflows, use templates, and modularize your pipeline components.
- **Classic Pipeline**: Provides a more straightforward approach with a GUI but lacks the flexibility and customization options available in YAML-based pipelines.

### Version Control and Collaboration

- **Multi-Stage Pipeline**: Pipeline definitions are stored in source control, making it easier to track changes, collaborate, and maintain version history.
- **Classic Pipeline**: Pipeline definitions are not stored in source control by default, making collaboration and version tracking more challenging.

### Ease of Use

- **Multi-Stage Pipeline**: Requires knowledge of YAML, which may have a steeper learning curve for some users.
- **Classic Pipeline**: User-friendly interface that is easier for beginners to use without needing to learn YAML.

### Reusability and Maintenance

- **Multi-Stage Pipeline**: Supports reusable templates and modular components, making it easier to maintain and update pipelines.
- **Classic Pipeline**: Limited reusability and modularity, which can make maintenance more cumbersome.

## Scenario Analysis

### Scenario: Developing a Distributed Workflow System

Given the scenario of developing a distributed system(multiple host/resources) with multiple environments, all resources hosted on-premise, and a team of well-experienced DevOps familiar with scripting languages like Python and Shell, the **Multi-Stage Pipeline** approach is recommended. Here are the reasons:

1. **Flexibility and Customization**:
   - **Multi-Stage Pipeline**: Offers high flexibility and customization through YAML. This allows you to define complex workflows, use templates, and modularize your pipeline components, which is essential for a distributed workflow system.
   - **Classic Pipeline**: Less flexible and customizable compared to YAML-based pipelines.

2. **Version Control and Collaboration**:
   - **Multi-Stage Pipeline**: Pipeline definitions are stored in source control, making it easier to track changes, collaborate, and maintain version history. This is crucial for managing separate development and production environments.
   - **Classic Pipeline**: Pipeline definitions are not stored in source control by default, making collaboration and version tracking more challenging.

3. **Reusability and Maintenance**:
   - **Multi-Stage Pipeline**: Supports reusable templates and modular components, making it easier to maintain and update pipelines. This is beneficial for a system with multiple environments and hosts.
   - **Classic Pipeline**: Limited reusability and modularity, which can make maintenance more cumbersome.

4. **Integration with Modern DevOps Practices**:
   - **Multi-Stage Pipeline**: Better integration with modern DevOps practices, which is suitable for a team of well-experienced DevOps professionals.
   - **Classic Pipeline**: Suitable for simpler use cases but may not provide the advanced features needed for a complex distributed workflow system.

5. **Script Language Familiarity**:
   - **Multi-Stage Pipeline**: Allows for the inclusion of scripts (Python, Shell) directly within the YAML definitions, providing a seamless way to integrate custom scripts into the CI/CD process.
   - **Classic Pipeline**: While it supports scripts, the integration is not as seamless or flexible as YAML-based pipelines.

## Summary

Both Multi-Stage Pipelines and Classic Pipelines have their strengths and use cases. Multi-Stage Pipelines are ideal for teams looking for flexibility, customization, and better integration with modern DevOps practices. They are also better suited for projects that require complex workflows and collaboration through version control.

Classic Pipelines, on the other hand, are suitable for simpler use cases and teams that prefer a user-friendly interface without the need to learn YAML. They provide a straightforward way to set up CI/CD pipelines but may lack the advanced features and flexibility of Multi-Stage Pipelines.

Choosing the right pipeline type depends on your team's needs, expertise, and the complexity of your CI/CD workflows.

___

Disclaimer: This blog post was partially created using GitHub Copilot for efficiency and content generation.
