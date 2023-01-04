global using System.Reflection;
global using System.Linq.Expressions;

global using eShop.Application.Dtos;
global using eShop.Application.Services;
global using eShop.Domain.Entities.Abstract;
global using eShop.Domain.Entities.Concrete;

global using eShop.Application.Queries.Orders;
global using eShop.Application.Queries.Products;
global using eShop.Application.Queries.Customers;
global using eShop.Application.Queries.Categories;

global using eShop.Application.Commands.Orders;
global using eShop.Application.Commands.Products;
global using eShop.Application.Commands.Customers;
global using eShop.Application.Commands.Categories;

global using eShop.Application.Repositories.OrderRepository;
global using eShop.Application.Repositories.ProductRepository;
global using eShop.Application.Repositories.CustomerRepository;
global using eShop.Application.Repositories.CategoryRepository;

global using MediatR;
global using AutoMapper;
global using FluentValidation;
global using Microsoft.AspNetCore.Http;
global using FluentValidation.AspNetCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
