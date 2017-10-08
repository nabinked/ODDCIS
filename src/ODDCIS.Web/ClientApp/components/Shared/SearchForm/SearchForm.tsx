import * as React from 'react';
import { withRouter } from 'react-router-dom'
import './search-form.scss';
import { RouteComponentProps } from 'react-router-dom'
import { SearchInput, Tag, RdfNode } from './SearchInput';
import utils from '../../../utils';
import { parse } from 'query-string'


interface SearchFormState {
    rdfTerms: Array<RdfNode>;
}
interface SearchFormProps extends RouteComponentProps<any> {
}
export const SearchForm = withRouter<SearchFormProps>(
    class Form extends React.Component<SearchFormProps, SearchFormState>   {
        constructor(props: SearchFormProps) {
            super(props);
            this.handleSubmit = this.handleSubmit.bind(this);
            this.onChange = this.onChange.bind(this);
            this.state = { rdfTerms: [] }
        }
        
        onChange(selectedRdfNodes: Array<RdfNode>) {
            this.setState({ rdfTerms: selectedRdfNodes });
        }
        public componentDidMount() {
            if (this.props.history.location.search) {
                fetch('/api/tags/parse' + this.props.history.location.search)
                    .then(response => response.json() as Promise<Array<RdfNode>>)
                    .then(data => {
                        this.setState({ rdfTerms: data });
                    });

            }
        }
        public render() {
            return <form autoComplete="off" action="/search" method="get" onSubmit={this.handleSubmit} className="search-form">
                <div className="text-center">
                    <SearchInput onChange={this.onChange} rdfTerms={this.state.rdfTerms} />
                    <input type="submit"
                        className="btn btn-outline-primary"
                        value="Search"
                    />
                </div>
            </form>
        }
        handleSubmit(event: React.FormEvent<HTMLFormElement>) {
            event.preventDefault();
            this.props.history.push('/search?' + utils.serializeArray(this.state.rdfTerms, "rdfNodes"));
        }
    })