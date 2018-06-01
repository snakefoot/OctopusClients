﻿using System.IO;
using System.Threading.Tasks;

using Octopus.Client.Model;

namespace Octopus.Client.Repositories.Async
{
    public interface ISpaceRepository :
        ICreate<SpaceResource>,
        IModify<SpaceResource>,
        IDelete<SpaceResource>,
        IFindByName<SpaceResource>,
        IGet<SpaceResource>
    {
        Task SetLogo(SpaceResource space, string fileName, Stream contents);
    }

    class SpaceRepository : BasicRepository<SpaceResource>, ISpaceRepository
    {
        public SpaceRepository(IOctopusAsyncClient client) : base(client, "Spaces")
        {
        }

        public Task SetLogo(SpaceResource space, string fileName, Stream contents)
        {
            return Client.Post(space.Link("Logo"), new FileUpload { Contents = contents, FileName = fileName }, false);
        }
    }
}