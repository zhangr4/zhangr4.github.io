# 博客系统设计

## 需求分析

功能：

1.header：home链接，social链接

2.侧边导航栏： 列出所有文章

3.显示博客文章
    - 博客文章内容，元数据

4.评论功能

    - 用户登录

    - 评论文章

5.发布文章功能

    - 需要后台管理

        - 用户登录

        - 文章编辑和上传

## 目标

学习使用Blazor实现该博客系统

学习领域驱动设计

学习UI设计和实现

## 系统设计

user story：

1. 作为一个管理员，登录系统
1. 作为一个管理员，登出系统
1. 作为一个管理员，发文章
1. 作为一个用户，看文章并评论

领域：

1. 用户管理系统

实体： 

用户类： id，name, email?


2. 文章系统

实体：

文章类: id, title, metadata, content

metadata包括：createdAt, last modified, author, tags


3. 评论系统

实体： 
评论类： id, content, metadata, blogid

metadata包括： createdAt, author, tags