using Characters;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    class EpisodeRepository : RepositoryBase<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public Episode GetEpisode(int id) => FindByCondition(e => e.Id.Equals(id)).FirstOrDefault();
    }
}
