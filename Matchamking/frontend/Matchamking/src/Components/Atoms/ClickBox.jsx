import StyledBox from "./BoxStyle";
import styled from "styled-components";
import React from 'react'
import {Link} from 'react-router-dom'

const StyledLink = styled(Link)`
    all:unset;
`
const StyledClickBox = styled(StyledBox)`
  margin-top: 2.5rem;
`

const ClickBox = ({text, redirection}) => {
  return (
    <StyledClickBox>
        <StyledLink to={redirection}> {text} </StyledLink>
    </StyledClickBox>
  )
}

export default ClickBox