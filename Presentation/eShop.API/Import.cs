global using System.Net;
global using System.Text;

global using eShop.Application.Dtos;
global using eShop.Application.Services;
global using eShop.Persistence.Services;
global using eShop.Infrastructure.Services;
global using eShop.Domain.Entities.Concrete;

global using eShop.Application.Queries.Orders;
global using eShop.Application.Queries.Products;
global using eShop.Application.Queries.Customers;
global using eShop.Application.Queries.Categories;

global using eShop.Application.Commands.Orders;
global using eShop.Application.Commands.Products;
global using eShop.Application.Commands.Customers;
global using eShop.Application.Commands.Categories;

global using MediatR;
global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
