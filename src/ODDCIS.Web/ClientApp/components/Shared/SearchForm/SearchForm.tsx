import * as React from 'react';
import { withRouter } from 'react-router-dom'
import './search-form.scss';
import { RouteComponentProps } from 'react-router-dom'
import { SearchInput, Tag, RdfNode } from './SearchInput';
import utils from '../../../utils';

interface SearchFormState {
    rdfTerms: RdfNode[];
}
interface SearchFormProps extends RouteComponentProps<any> {
    query: string;
}
export const SearchForm = withRouter<SearchFormProps>(
    class Form extends React.Component<SearchFormProps, SearchFormState>   {
        tags: Array<Tag>;
        constructor(props: SearchFormProps) {
            super(props);
            this.handleSubmit = this.handleSubmit.bind(this);
            this.onChange = this.onChange.bind(this);
        }
        onChange(selectedRdfNodes: Array<RdfNode>) {
            this.setState({ rdfTerms: selectedRdfNodes });
        }
        public render() {
            return <form action="/search" method="get" onSubmit={this.handleSubmit} className="form-inline search-form">
                <div className="text-center">
                    <SearchInput tags={this.tags} onChange={this.onChange} />
                    <input type="submit"
                        className="btn btn-outline-primary"
                        value="Search"
                    />
                </div>
            </form>
        }
        handleSubmit(event: React.FormEvent<HTMLFormElement>) {
            event.preventDefault();
            this.props.history.push('/search?=' + utils.serializeArray(this.state.rdfTerms, "RdfTerms"));
        }
    })