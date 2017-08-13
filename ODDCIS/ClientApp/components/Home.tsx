import * as React from 'react';
import '../sass/components/home.scss';

interface HomeState {
    searchTerm: string
}
export class Home extends React.Component<{}, HomeState> {

    constructor() {
        super();
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    public render() {
        return <div className="home">
            <form onSubmit={this.handleSubmit} className="form-inline search-form">
                <div className="form-group">
                    <input
                        type="text"
                        className="form-control"
                        placeholder="enter search term"
                        onChange={this.handleInputChange}
                    />
                    <input type="submit"
                        className="btn btn-outline-primary"
                        value="Search"
                    />
                </div>
            </form>
        </div>;
    }
    handleInputChange(event: React.ChangeEvent<HTMLInputElement>) {
        console.log('input change');
        this.setState({
            searchTerm: (event.target as HTMLInputElement).value
        })
    }
    handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        console.log('form submit');
        event.preventDefault();
        console.log(this.state)
    }
}
