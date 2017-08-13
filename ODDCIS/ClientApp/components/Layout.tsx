import * as React from 'react';
import { NavMenu } from './NavMenu';
import { Footer } from './Footer';
import '../sass/components/layout.scss';


export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div>
            <header>
                <NavMenu />
            </header>
            <main>
                <div className="content">
                    {this.props.children}
                </div>
            </main>
            <footer>
                <Footer />
            </footer>
        </div>
    }
}
