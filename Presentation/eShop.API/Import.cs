﻿global using System.Net;

global using eShop.Application.Dtos;
global using eShop.Persistence.Services;
global using eShop.Infrastructure.Services;
global using eShop.Application.Paginations;
global using eShop.Domain.Entities.Concrete;
global using eShop.Application.Queries.Products;
global using eShop.Application.Commands.Products;
global using eShop.Application.Repositories.OrderRepository;
global using eShop.Application.Repositories.CategoryRepository;
global using eShop.Application.Repositories.CustomerRepository;

global using MediatR;
global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
