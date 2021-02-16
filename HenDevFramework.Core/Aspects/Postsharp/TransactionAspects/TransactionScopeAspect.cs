using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace HenDevFramework.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;

        //Bu Frameworkte parametresiz olarak kullanıcaz
        public TransactionScopeAspect()
        {

        }

        //Parametreli kullanım
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);

        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            //var transactionScope = (TransactionScope) args.MethodExecutionTag;
            //transactionScope?.Complete();

            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            //var transactionScope = (TransactionScope) args.MethodExecutionTag;
            //transactionScope?.Dispose();

            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
