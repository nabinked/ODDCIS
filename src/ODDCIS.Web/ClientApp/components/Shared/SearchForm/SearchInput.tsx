import * as React from 'react';
import { WithContext as ReactTags } from 'react-tag-input';
import './search-input.scss';
import utils from '../../../utils';

interface Tag {
    id?: number;
    text: string;
}

interface RdfNode {
    uri: string;
    label: string;
    comment: string;
    rdfNodeType: number;
    propertyOf:string; // if its a property then the uri for which it is the property
}

interface SearchFormInputProps {
    tags: Array<Tag>
}
interface SearchFormInputState {
    tags: Array<Tag>,
    selectedRdfTermList: Array<RdfNode>
    suggestions: Array<string>
    suggestedRdfTermList?: Array<RdfNode>
}
export class SearchInput extends React.Component<SearchFormInputProps, SearchFormInputState>
{
    constructor(props: SearchFormInputProps) {
        super(props);
        this.state = {
            tags: [],
            suggestions: [],
            selectedRdfTermList: []
        };
        this.handleDelete = this.handleDelete.bind(this);
        this.handleAddition = this.handleAddition.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }
    shoudlFecthSuggestions(): boolean {
        return this.state.suggestions.length == 0;
    }
    fetchSuggestions(input) {
        fetch('/api/search/suggestions?' + utils.serializeArray(this.state.selectedRdfTermList, "precedentRdfTerms"))
            .then(response => response.json() as Promise<Array<RdfNode>>)
            .then(data => {
                this.setSuggestions(data);
            });
    }
    setSuggestions(rdfTermList: Array<RdfNode>): void {
        this.setState({ suggestedRdfTermList: rdfTermList, suggestions: this.suggestionsFromRdfTermList(rdfTermList) })
    }
    suggestionsFromRdfTermList(rdfTermList: Array<RdfNode>): string[] {
        var suggestions: Array<string> = [];
        var count = 1;
        for (let rdfTerm of rdfTermList) {
            suggestions.push(count + ". " + rdfTerm.label)
            count++;
        }
        return suggestions;
    }
    addSelectedRdfTerm(tag: string) {
        this.setState(function (prevState: SearchFormInputState, props: SearchFormInputProps) {
            let tags = prevState.tags;
            let rdfTermList = prevState.selectedRdfTermList;
            var splitted = tag.split(".");
            splitted.splice(0, 1);
            tags.push({ text: splitted.join("") })
            rdfTermList.push(this.getRdfTermFromTag(tag));
            return {
                tags: tags,
                selectedRdfTermList: rdfTermList,
                suggestions: []
            }
        });

    }
    clearSuggestions(): void {
        this.setSuggestions([]);
    }
    getRdfTermFromTag(tag: string): RdfNode {
        var index = parseInt(tag.split(".")[0]) - 1;
        return this.state.suggestedRdfTermList[index];
    }

    handleInputChange(input: string) {
        if (this.shoudlFecthSuggestions()) {
            this.fetchSuggestions(input);
        }
    }
    handleDelete(i) {
        let tags = this.state.tags;
        if (i == tags.length - 1) {
            tags.splice(i, 1);
            this.setState({
                tags: tags,
                suggestions: []
            });
        } else {
            alert("Can only remove the last tag.")
        }
    }
    handleAddition(tag) {
        this.addSelectedRdfTerm(tag);
    }
    handleFilterSuggestions(textInputValue, possibleSuggestionsArray) {

        var lowerCaseQuery = textInputValue.toLowerCase()

        var newSuggestions = possibleSuggestionsArray.filter(function (suggestion) {
            return suggestion.toLowerCase().includes(lowerCaseQuery)
        })
        return newSuggestions.splice(0, 5);
    }
    render() {
        const { tags } = this.state;
        return (
            <ReactTags tags={tags}
                placeholder="Start searching for concepts"
                handleInputChange={this.handleInputChange}
                handleDelete={this.handleDelete}
                handleFilterSuggestions={this.handleFilterSuggestions}
                minQueryLength={1}
                suggestions={this.state.suggestions}
                handleAddition={this.handleAddition} />
        )
    }
}   