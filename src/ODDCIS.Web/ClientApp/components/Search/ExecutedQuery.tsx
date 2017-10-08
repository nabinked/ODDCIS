import * as React from 'react'
import { SFC } from 'react'

interface ExecutedQueryProps {
    executedQuery: string;
}

export const ExecutedQuery: SFC<ExecutedQueryProps> = ({ executedQuery }) => <div>
    <h6 className="text-info">Executed Query</h6>
    <p className="small alert alert-info">
        {executedQuery}
        </p>
</div>;