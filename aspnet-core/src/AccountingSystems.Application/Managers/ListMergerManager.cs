using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Managers
{
    public class ListMergerManager<SourceDto, TargetEntity>
        where SourceDto : EntityDto<int>
        where TargetEntity : Entity<int>
    {
        private List<SourceDto> _source { get; }
        private List<TargetEntity> _target { get; }
        public IRepository<TargetEntity> _repo { get; }
        public IObjectMapper _objectMapper { get; }

        public ListMergerManager(List<SourceDto> Source, List<TargetEntity> Target, IRepository<TargetEntity> Repo, IObjectMapper objectMapper)
        {
            this._source = Source;
            this._target = Target;
            this._repo = Repo;
            _objectMapper = objectMapper;
        }

        public async Task<bool> Merge()
        {
            var AttributeIdList = _source.Select(x => x.Id);

            foreach (var d in _target.FindAll(x => !AttributeIdList.Contains(x.Id)))
            {
                await _repo.DeleteAsync(d.Id);
            }

            foreach (var attr in _source)
            {
                if (_target.Exists(x => x.Id == attr.Id))
                {
                    var current = _target.Single(x => x.Id == attr.Id);
                    var updated = _objectMapper.Map(attr, current);
                }
                else
                {
                    var attrEntity = _objectMapper.Map<TargetEntity>(attr);
                    _repo.Insert(attrEntity);
                }
            }

            return true;
        }
    }
}