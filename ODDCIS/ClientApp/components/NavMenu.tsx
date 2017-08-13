import * as React from 'react';
import '../sass/components/navmenu.scss';


export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <nav className="navbar-main navbar sticky-top">
            <a className="navbar-brand" href="#">
                ODDCIS <small>Ontology Driven Dementia Care Information System</small>
            </a>
        </nav>
    }
}
