using DreamRosterBuilding.Data.Entities;
using DreamRosterBuilding.Data.Enums;
using DreamRosterBuilding.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Icon
{
    public class IconManager : IIconService
    {
        private readonly IRepository<IconEntity> _repository;

        public IconManager(IRepository<IconEntity> repository)
        {
            _repository = repository;
        }
        public int GetIconId(HairColor hairColor, Skin skin, Tattoo? tattoo) // -> This is for finding iconıd from feautures. I have data like id1, haircolor=x, skin=x, tattoo=x?,*imagePath* so for dynamic icon changes I will use this
        {
            return _repository.Get(i=>i.HairColor==hairColor&&i.Skin==skin&&i.Tattoo==tattoo).Id;
        }
    }
}
