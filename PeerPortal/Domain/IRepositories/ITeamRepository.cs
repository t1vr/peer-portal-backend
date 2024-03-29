﻿using Domain.Entities;

namespace Domain.IRepositories
{
    /// <summary>
    /// Interface to access Team table in database
    /// </summary>
    public interface ITeamRepository : IGenericRepository<Team>
    {
        /// <summary>
        /// Gets team by id
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id"></param>
        /// <returns>Team</returns>
        Task<Team?> GetAsync(IQueryable<Team> query, string id);

        /// <summary>
        /// Gets all team given a user Id
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id"></param>
        /// <returns>List of Teams</returns>
        Task<List<Team>> GetAllAsync(IQueryable<Team> query,string id);
    }
}
