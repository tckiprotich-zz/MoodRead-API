using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using COLLINS.Data;
using COLLINS.Models;


namespace COLLINS.Data
{
    public class MoodBookDBContext : DbContext
    {
        public MoodBookDBContext(DbContextOptions<MoodBookDBContext> options) : base(options)
        {
        }

        public DbSet<BookDetails> BookDetails { get; set; } = null!;

    }
}