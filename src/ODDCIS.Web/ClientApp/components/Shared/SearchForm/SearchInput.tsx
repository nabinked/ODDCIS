import * as React from 'react';
import { WithContext as ReactTags } from 'react-tag-input';
import './search-input.scss';
import utils from '../../../utils';

interface Tag {
    id: number;
    text: string;
}

interface RdfTerm {
    uri: string;
    label: string;
    comment: string;
}

interface PropertyRdfTerm extends RdfTerm {
    subject: RdfTerm;
}

interface SearchFormInputProps {
    tags: Array<Tag>
}
interface SearchFormInputState {
    tags: Array<Tag>,
    rdfTermList: Array<RdfTerm>
    suggestions: Array<string>
}
export class SearchInput extends React.Component<SearchFormInputProps, SearchFormInputState>
{
    constructor(props: SearchFormInputProps) {
        super(props);
        this.state = {
            tags: [{ id: 1, text: "Thailand" }, { id: 2, text: "India" }],
            suggestions: [],
            rdfTermList: null
        };
        this.handleDelete = this.handleDelete.bind(this);
        this.handleAddition = this.handleAddition.bind(this);
    }
    handleInputChange() {

    }
    handleDelete(i) {
        let tags = this.state.tags;
        if (i == tags.length - 1) {
            tags.splice(i, 1);
            this.setState({ tags: tags });
        } else {
            alert("Can only remove the last tag.")
        }
    }
    fetchSuggestions(input) {
        fetch('/api/search/suggestions?' + utils.serialize(this.state.rdfTermList))
            .then(response => response.json() as Promise<Array<RdfTerm>>)
            .then(data => {
                this.setState({ rdfTermList: data });
            });
    }
    handleFilterSuggestions(textInputValue, possibleSuggestionsArray) {

        var lowerCaseQuery = textInputValue.toLowerCase()

        return possibleSuggestionsArray.filter(function (suggestion) {
            return suggestion.toLowerCase().includes(lowerCaseQuery)
        })
    }
    handleAddition(tag) {
        let tags = this.state.tags;
        tags.push({
            id: tags.length + 1,
            text: tag
        });
        this.setState({ tags: tags });
    }
    render() {
        const { tags } = this.state;
        return (
            <div>
                <ReactTags tags={tags}
                    placeholder="Start searching for concepts"
                    handleInputChange={this.handleInputChange}
                    handleDelete={this.handleDelete}
                    handleFilterSuggestions={this.handleFilterSuggestions}
                    minQueryLength={1}
                    suggestions={this.state.suggestions}
                    handleAddition={this.handleAddition} />
            </div>
        )
    }
}   