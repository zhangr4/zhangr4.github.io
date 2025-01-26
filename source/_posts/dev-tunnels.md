---
title: Introduction to Microsoft DevTunnels
author: Zhangr4
date: 2025-Jan-26
tags: 
  - DevTunnels
  - Azure
---

[Microsoft DevTunnels](https://learn.microsoft.com/en-us/azure/developer/dev-tunnels/) is a powerful tool that allows developers to securely expose their local development environment to the internet. This can be incredibly useful for testing webhooks, APIs, or any other service that requires external access to your local machine.

{% asset_img architect-diagram.jpg %}

- **Secure Tunnels**: DevTunnels ensures that your local environment is securely accessible from the internet.
- **Easy Setup**: With simple configuration, you can quickly set up a tunnel and start testing.
- **Integration with Development Tools**: DevTunnels integrates seamlessly with popular development tools, making it easy to use in your existing workflow.

<!-- more -->

## Visual Studio Integration

DevTunnels can be found easily in visual studio.

{% asset_img vs.png %}

please check [Microsoft Documentation](https://learn.microsoft.com/en-us/connectors/custom-connectors/port-tunneling) for more details.

## Use DevTunnels CLI

DevTunnels can also be used via CLI

{% asset_img cli.png %}

Please check **[DevTunnels Documentation](https://learn.microsoft.com/en-us/azure/developer/dev-tunnels/)** for more details

There are two introduction video which also quite helpful:

{% youtube yBiOGgUFD68 %}

{% youtube yCYLurylgj8 %}

## How DevTunnels Work

Microsoft DevTunnels leverages Azure Relay to securely expose your local development environment to the internet. Azure Relay is a service that allows you to connect your on-premises applications to the cloud without opening up inbound ports on your firewall.

___

Disclaimer: This blog post was partially created using GitHub Copilot for efficiency and content generation.