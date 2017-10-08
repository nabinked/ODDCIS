import * as React from 'react';
import '../sass/components/navmenu.scss';
import { Link } from 'react-router-dom'


export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <nav className="navbar-main navbar sticky-top">
            <Link to="/" title="Ontology Driven Information Retrieval System" className="navbar-brand">
                ODIRS 
            </Link>
        </nav>
    }
}
