using DDDInPractice.Logic.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Repository
{
    public class IncludeQueryBuilder<TEntity, TMember> : QueryBuilder<TEntity>, IIncludeQueryBuilder<TEntity, TMember>
        where TEntity : class, IEntity
    {
        private readonly IIncludableQueryable<TEntity, TMember> _singleMember;
        private readonly IIncludableQueryable<TEntity, IEnumerable<TMember>> _collectionMember;


        public IncludeQueryBuilder(IIncludableQueryable<TEntity, TMember> query) : base(query)
        {
            _singleMember = query;
        }

        public IncludeQueryBuilder(IIncludableQueryable<TEntity, IEnumerable<TMember>> query) : base(query)
        {
            _collectionMember = query;
        }


        public IIncludeQueryBuilder<TEntity, TRelation> ThenInclude<TRelation>(Expression<Func<TMember, IEnumerable<TRelation>>> member)
        {
            var query =
                _singleMember != null ? _singleMember.ThenInclude(member)
                    : _collectionMember.ThenInclude(member);

            return new IncludeQueryBuilder<TEntity, TRelation>(query);
        }

        public IIncludeQueryBuilder<TEntity, TRelation> ThenInclude<TRelation>(Expression<Func<TMember, ICollection<TRelation>>> member)
        {
            var query =
                _singleMember != null ? _singleMember.ThenInclude(member)
                    : _collectionMember.ThenInclude(member);

            return new IncludeQueryBuilder<TEntity, TRelation>(query);
        }

        public IIncludeQueryBuilder<TEntity, TRelation> ThenInclude<TRelation>(Expression<Func<TMember, List<TRelation>>> member)
        {
            var query =
                _singleMember != null ? _singleMember.ThenInclude(member)
                    : _collectionMember.ThenInclude(member);

            return new IncludeQueryBuilder<TEntity, TRelation>(query);
        }

        public IIncludeQueryBuilder<TEntity, TRelation> ThenInclude<TRelation>(Expression<Func<TMember, TRelation>> member)
        {
            var query =
                _singleMember != null ? _singleMember.ThenInclude(member)
                                      : _collectionMember.ThenInclude(member);

            return new IncludeQueryBuilder<TEntity, TRelation>(query);
        }
    }
}
