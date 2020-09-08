import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import "tabler-react/dist/Tabler.css";
import { Button, Page } from "tabler-react";
import SiteWrapper from './../SiteWrapper.react';

export default (props: { children?: React.ReactNode }) => (
    
    <React.Fragment>
        <SiteWrapper>
            <Page.Content>
                {props.children}
            </Page.Content>
        </SiteWrapper>
    </React.Fragment>
);
