###
### MAKEFILE
###	IVS Projekt Kalkulacka 2021 
### xgasta00_xprikr33_xvlasa16
###	
### Pouziti (specialni stavy):
###          "make profiling" - musi byt rucne sbuildeno
###			 "make all/run" - musi byt rucne sbuildeno
###			 "make clean" - smaze bin a obj slozky, ktere se ihned pote opet automaticky vytvori, 
###							pro spusteni programu je za potrebi sbuildit prvne MathLib a pote az celou solutionu,
###							pro spusteni profilingu je za potrebi sbuildit Profiling

FileCalculator=Calculator/bin/Release/net5.0-windows/Calculator.exe
FileProfiling=Profiling/bin/Release/net5.0/Profiling.exe
resultDir=.\xgasta00_xprikr33_xvlasa16

.PHONY: all pack clean profile help run doc

all: run

pack: doc
ifneq ("$(wildcard $(resultDir))", "")
		rm -f -r "xgasta00_xprikr33_xvlasa16"
endif
	mkdir "$(resultDir)"
	mkdir "$(resultDir)\doc"
	mkdir "$(resultDir)\install"
	mkdir "$(resultDir)\repo"
	xcopy .\..\doc\html /s /q $(resultDir)\doc
	xcopy .\setup.msi xgasta00_xprikr33_xvlasa16\install
	xcopy .\setup.exe xgasta00_xprikr33_xvlasa16\install
ifneq ("$(wildcard "IVS")", "")
		rm -f -r "IVS"
endif
	git clone https://github.com/dejvones/IVS
	xcopy .\IVS /s /q $(resultDir)\repo
	rm -f -r "IVS"
	tar.exe -c -f xgasta00_xprikr33_xvlasa16.zip xgasta00_xprikr33_xvlasa16
	rm -f -r "xgasta00_xprikr33_xvlasa16"

clean: 
	rm -f -r ./*/bin
	rm -f -r ./*/obj

profile:
	$(FileProfiling) < ./Profiling/test/data100.txt

help: 
	$(info Napoveda k pouziti makefile)
	$(info make [option])
	$(info pack -- zabali na odevzdani)
	$(info clean -- odstarni nepotrebne soubory)
	$(info profile -- spusti profiling)
	$(info run -- spusti kalkulacku, pokud neni vytvoreny spustitelny soubor, provede se build)

run:
	$(FileCalculator)

doc:
	doxygen