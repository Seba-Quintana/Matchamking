import React from 'react'
import styled from 'styled-components'
import MiddleButtonStyle from './MiddleButtonStyle'
import badrequest from '../../assets/bxs-user-x.svg'
import goodrequest from '../../assets/bx-check.svg'

const StyledPopup = styled.dialog`
    position: absolute;
    border: 0;
    border-radius: 2px;
    width: 35%;
    height: 250px;
    display: flex;
    text-align: center;
    justify-content: space-around;
    align-items: center;
    font-family: 'Inter', sans-serif;
    font-size: medium;
    opacity: 90%;
    flex-direction: column;
  
    @media (max-width: 800px){
      height: 40%;
      width: 90%;
    justify-content: center;

    }
`
const CloseButton = styled(MiddleButtonStyle)`
  color: white;
  margin: 20px;
`
const Image = styled.img`
  height: 30px;
  width: 30px;
  margin: 20px;
`

function PopupStyle(props) {
  if( props.requestState === -1 )
  {
    return (
      <StyledPopup>
        <Image src={badrequest}></Image>
        {props.text}
        <CloseButton onClick={() => props.setRequested(false)}>
          Cerrar
        </CloseButton>
      </StyledPopup>
    )
  }
    return (
      <StyledPopup>
        <Image src={goodrequest}></Image>
        {props.text}
        <CloseButton onClick={() => props.setRequested(false)}>
          Cerrar
        </CloseButton>
      </StyledPopup>
    )

}

export default PopupStyle