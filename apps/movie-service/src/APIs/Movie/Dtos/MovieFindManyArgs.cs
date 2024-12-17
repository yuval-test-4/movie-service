using Microsoft.AspNetCore.Mvc;
using MovieService.APIs.Common;
using MovieService.Infrastructure.Models;

namespace MovieService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class MovieFindManyArgs : FindManyInput<Movie, MovieWhereInput> { }
