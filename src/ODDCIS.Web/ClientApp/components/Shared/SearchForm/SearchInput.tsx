import * as React from 'react';
import { WithContext as ReactTags } from 'react-tag-input';
import './search-input.scss';
import utils from '../../../utils';

export interface Tag {
    id?: string;
    text: string;
}

export interface RdfNode {
    uri: string;
    label: string;
    comment: string;
    type: number;
    PredicateOf: string; // if its a property then the uri for which it is the property
}

interface SearchFormInputProps {
    tags: Array<Tag>;
    onChange?: Function;
}
interface SearchFormInputState {
    selectedTags: Array<Tag>,
    selectedRdfTermList: Array<RdfNode>
    suggestions: Array<string>
    suggestedRdfTermList?: Array<RdfNode>
}
export class SearchInput extends React.Component<SearchFormInputProps, SearchFormInputState>
{

    idDelimiter: string;
    constructor(props: SearchFormInputProps) {
        super(props);
        this.state = {
            selectedTags: [],
            suggestions: [],
            selectedRdfTermList: []
        };
        this.idDelimiter = ": "
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
            suggestions.push(count + this.idDelimiter + rdfTerm.label)
            count++;
        }
        return suggestions;
    }

    clearSuggestions(): void {
        this.setSuggestions([]);
    }
    getRdfTermFromTag(tag: string): RdfNode {
        var index = parseInt(tag.split(this.idDelimiter)[0]) - 1;
        return this.state.suggestedRdfTermList[index];
    }
    getRdfTermFromTags(tags: Array<Tag>): Array<RdfNode> {
        var self = this;
        var rdfTerms = tags.map(function (tag: Tag, index: number, array: Tag[]) {
            return self.getRdfTermFromTag(tag.text);
        });
        return rdfTerms;
    }

    handleInputChange(input: string) {
        if (this.shoudlFecthSuggestions()) {
            this.fetchSuggestions(input);
        }
    }
    addSelectedRdfTerm(tag: string) {
        this.setState(function (prevState: SearchFormInputState, props: SearchFormInputProps) {
            let tags = prevState.selectedTags;
            let rdfTermList = prevState.selectedRdfTermList;
            var splitted = tag.split(this.idDelimiter);
            splitted.splice(0, 1);
            tags.push({ text: splitted.join("") })
            rdfTermList.push(this.getRdfTermFromTag(tag));
            this.props.onChange(rdfTermList);
            return {
                tags: tags,
                selectedRdfTermList: rdfTermList,
                suggestions: [],
                suggestedRdfTermList: []
            }
        });

    }
    removeTag(i: number): any {
        let selectedTags = this.state.selectedTags;
        let selectedRdfTermList = this.state.selectedRdfTermList;
        if (i == selectedTags.length - 1) {
            selectedTags.splice(i, 1);
            selectedRdfTermList.splice(i, 1);
            this.setState({
                selectedRdfTermList: selectedRdfTermList,
                suggestedRdfTermList: [],
                selectedTags: selectedTags,
                suggestions: []
            });
            this.props.onChange(selectedRdfTermList);
        } else {
            alert("Can only remove the last tag.")
        }
    }
    handleDelete(i) {
        this.removeTag(i);
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
        const { selectedTags } = this.state;
        return (
            <ReactTags tags={selectedTags}
                placeholder="Start searching for concepts"
                minQueryLength={1}
                suggestions={this.state.suggestions}                
                handleInputChange={this.handleInputChange}
                handleFilterSuggestions={this.handleFilterSuggestions}
                handleDelete={this.handleDelete}
                handleAddition={this.handleAddition} />
        )
    }
}   