import * as React from 'react';
import { NavMenu } from './NavMenu';
import { Footer } from './Footer';
import {ForkMeOnGitHub} from './ForkMeOnGitHub'
import '../sass/components/layout.scss';


export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div className="app-wrapper">
            <header>
                <NavMenu />
            </header>
            <main>
                <div className="container content">
                    {this.props.children}
                </div>
            </main>
            <footer>
                <Footer />
            </footer>
            <ForkMeOnGitHub repoUrl="https://github.com/nabinked/ODDCIS"/>
        </div>
    }
}
