import * as React from 'react';

var styles = {
    content: {
        textAlign: 'center',
        fontSize: '35px'
    }
};

interface LoaderProps {
    text?: string,
    speed?: number
}

interface LoaderState {
    text: string,
}

export class Loader extends React.Component<LoaderProps, LoaderState> {
    interval: number;
    originalText: string;
    constructor(props) {
        super(props);
        this.originalText = props.text;
        this.state = {
            text: this.originalText,
        };
    }
    public static defaultProps: Partial<LoaderProps> = {
        text: "Loading",
        speed:300
    };
    componentDidMount() {
        var stopper = this.originalText + '...'
        this.interval = setInterval(function () {
            if (this.state.text === stopper) {
                this.setState(function () {
                    return {
                        text: this.originalText
                    }
                });
            } else {
                this.setState(function (prevState) {
                    return {
                        text: prevState.text + '.'
                    }
                })
            }
        }.bind(this), this.props.speed)
    }
    componentWillUnmount() {
        window.clearInterval(this.interval)
    }
    render() {
        return (
            <p style={styles.content}>
                {this.state.text}
            </p>
        )
    }
}