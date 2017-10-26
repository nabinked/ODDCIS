
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import * as RoutesModule from './routes';
let routes = RoutesModule.routes;
import './sass/site.scss';

function renderApp() {
    // This code starts up the React app when it runs in a browser. It sets up the routing
    // configuration and injects the app into a DOM element.
    ReactDOM.render(
        <AppContainer>
            <BrowserRouter children={routes} />
        </AppContainer>,
        document.getElementById('app-oddcis')
    );
}

renderApp();

// Allow Hot Module Replacement
if (module.hot) {
    //Reload HMR hack for style sheets
    reloadStyleSheets()
    module.hot.accept('./routes', () => {
        routes = require<typeof RoutesModule>('./routes').routes;
        renderApp();
    });
}

function reloadStyleSheets() {
    const reporter = (window as any).__webpack_hot_middleware_reporter__;
    const success = reporter.success;
    reporter.success = function () {
        let nodelist = document.querySelectorAll('link[href][rel=stylesheet]');
        Array.prototype.forEach.call(nodelist, (link:HTMLAnchorElement) => {
            const nextStyleHref = link.href.replace(/(\?\d+)?$/, `?${Date.now()}`);
            link.href = nextStyleHref;
        });
        success();
    };
}