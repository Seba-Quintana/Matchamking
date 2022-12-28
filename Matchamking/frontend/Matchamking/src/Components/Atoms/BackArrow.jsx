import React from 'react'
import styled from 'styled-components'
import backarrow from '../../assets/bx-arrow-back.svg'
import BoxIconStyle from './BoxIconStyle'
import { useNavigate } from 'react-router-dom'


const StyledBackArrow = styled.div`
  position: absolute;
  align-self: flex-start;
  left: 1rem;
  top: 0.5rem;
  width: 35px;
  height: auto;
  color: #ffffff;
  cursor: pointer;
`

const BackArrow = ({navigate}) => {

  const navigation = useNavigate();
  return (
    <StyledBackArrow>
      <BoxIconStyle onClick={() => navigation(navigate)}>
        <img src={backarrow}></img>
      </BoxIconStyle>
    </StyledBackArrow>
  )
}

export default BackArrow