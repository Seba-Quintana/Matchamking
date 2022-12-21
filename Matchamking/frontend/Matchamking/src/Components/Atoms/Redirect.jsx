import React from 'react'
import {Link} from 'react-router-dom'
import styled from 'styled-components'

const StyledLink = styled(Link)`
background-color: white;
`
const Redirect = ({redirection}) => {
  return (
    <StyledLink to={redirection}></StyledLink>
  )
}

export default Redirect