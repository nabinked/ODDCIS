import * as React from 'react'
import { SFC } from 'react'

interface ExecutedQueryProps {
    executedSparqlQuery: string;
    requestedSemanticQuery: string;
}

export const ExecutedQuery: SFC<ExecutedQueryProps> = ({ executedSparqlQuery, requestedSemanticQuery }) => <div className="executed-query">
    {
        requestedSemanticQuery && <div>
            <h6 className="text-secondary">Requested Semantic Query</h6>
            <p className="small alert alert-secondary">
                {requestedSemanticQuery}
            </p>
        </div>

    }

    <h6 className="text-success">Executed SPARQL Query</h6>
    <p className="small alert alert-success">
        {executedSparqlQuery}
    </p>
</div>;